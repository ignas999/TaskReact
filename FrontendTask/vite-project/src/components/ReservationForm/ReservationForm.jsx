import React, { useState, useEffect } from 'react';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const ReservationForm = ({ book, onSubmit, onClose }) => {
  const [type, setType] = useState('regular');
  const [reservationDate, setReservationDate] = useState('');
  const [quickPickup, setQuickPickup] = useState(false);
  const [discountMessage, setDiscountMessage] = useState('');
  const [price, setPrice] = useState(0);

  const SERVICE_FEE = 3; 
  const QUICK_PICKUP_FEE = 5; 
  const DAILY_RATE_BOOK = 2; 
  const DAILY_RATE_AUDIOBOOK = 3; 

  useEffect(() => {
    if (reservationDate) {
      const selectedDate = new Date(reservationDate);
      const today = new Date();
      today.setHours(0, 0, 0, 0); 
      const daysDifference = Math.floor((selectedDate - today) / (1000 * 60 * 60 * 24));
  
      
      if (daysDifference >= 0) {
        let basePrice = 0;
  
        
        if (type === 'regular') {
          basePrice = DAILY_RATE_BOOK * daysDifference;
        } else if (type === 'audiobook') {
          basePrice = DAILY_RATE_AUDIOBOOK * daysDifference;
        }
  
        
        let finalPrice = basePrice + SERVICE_FEE; 
  
        
        let discount = 0;
        if (daysDifference > 3 && daysDifference <= 10) {
          discount = 0.10; 
          setDiscountMessage('A 10% discount has been applied for reservations longer than 3 days.');
        } else if (daysDifference > 10) {
          discount = 0.20; 
          setDiscountMessage('A 20% discount has been applied for reservations longer than 10 days.');
        } else {
          setDiscountMessage(''); 
        }
  
        
        if (quickPickup) {
          finalPrice += QUICK_PICKUP_FEE;
        }

        
        finalPrice -= finalPrice * discount;
  

  
        
        setPrice(finalPrice);
      } else {
        setDiscountMessage(''); 
        setPrice(0); 
      }
    }
  }, [reservationDate, type, quickPickup]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const today = new Date();
    const selectedDate = new Date(reservationDate);

    if (selectedDate < today) {
      toast.error('Please select a valid future date.', {
        position: "top-right",
      });
      return;
    }

    const reservationData = {
      startDate: today.toISOString(),               
      finishDate: selectedDate.toISOString(),       
      bookType: type,                               
      price: price,                                 
      quickPickup: quickPickup ? 'yes' : 'no',      
    };

    console.log('Sending reservation data:', reservationData);

    
    try {
      const response = await fetch(`http://localhost:5149/api/Reservations/${book.id}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(reservationData),
      });

      if (response.ok) {
        toast.success('Reservation successfully created!', {
          position: "top-right",
        });
        onSubmit(reservationData);
      } else {
        const errorData = await response.json();
        console.error('Error details:', errorData);
        toast.error('Failed to create reservation. Please check your data.', {
          position: "top-right",
        });
      }
    } catch (error) {
      console.error('Error occurred:', error);
      toast.error('Error creating reservation. Please try again later.', {
        position: "top-right",
      });
    }

    onClose(); 
  };


  const todayFormatted = new Date().toISOString().split('T')[0];

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
      <div className="bg-white p-6 rounded-lg shadow-lg w-full max-w-lg relative">
        <h2 className="text-lg font-bold mb-4">Reserve "{book.title}"</h2>

        
        <p className="text-lg font-bold mb-4">Total Price: €{price.toFixed(2)}</p>

        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="type">Reservation Type</label>
            <select
              id="type"
              value={type}
              onChange={(e) => setType(e.target.value)}
              className="block w-full p-2 mt-2 border"
            >
              <option value="regular">Regular</option>
              <option value="audiobook">Audiobook</option>
            </select>
          </div>

          <div className="mb-4">
            <label htmlFor="reservationDate">Reservation Date</label>
            <input
              type="date"
              id="reservationDate"
              value={reservationDate}
              onChange={(e) => setReservationDate(e.target.value)}
              className="block w-full p-2 mt-2 border"
              min={todayFormatted} 
            />
          </div>

          <div className="mb-4">
            <label>
              <input
                type="checkbox"
                checked={quickPickup}
                onChange={(e) => setQuickPickup(e.target.checked)}
              />
              Quick Pickup
            </label>
          </div>

        
          {discountMessage && (
            <p className="text-green-500 font-semibold">{discountMessage}</p>
          )}

          <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded">
            Submit Reservation
          </button>
          <button
            type="button"
            className="ml-4 text-red-500"
            onClick={onClose}
          >
            Cancel
          </button>
        </form>
      </div>
    </div>
  );
};

export default ReservationForm;
