import React, { useState } from 'react';

const ReservationCard = ({ reservation, onDelete }) => {
  const { book, startDate, finishDate, price, quickPickup } = reservation;
  const [showModal, setShowModal] = useState(false); 

  const handleDelete = async () => {
    try {
      const response = await fetch(`http://localhost:5149/api/reservations/${reservation.id}`, {
        method: 'DELETE',
      });

      if (!response.ok) {
        throw new Error('Failed to delete reservation');
      }

      
      onDelete(reservation.id);
      setShowModal(false); 
    } catch (error) {
      console.error('Error deleting reservation:', error);
      alert(error.message);
    }
  };

  return (
    <div className="w-1/3 max-w-sm rounded overflow-hidden shadow-lg bg-white m-4">
      <img className="w-full h-48 object-cover" src={book.picture} alt={book.title} />
      <div className="px-6 py-4">
        <div className="font-bold text-xl mb-2">{book.title}</div>

        
        <div className="grid-cols-3 gap-2 text-gray-700 text-base mb-4">
         
          <div className="flex justify-between col-span-1">
            <span>Author:</span>
            <span>{book.author}</span>
          </div>

        
          <div className="flex justify-between col-span-1">
            <span>Year:</span>
            <span>{book.year}</span>
          </div>

          
          <div className="flex justify-between col-span-1">
            <span>Start Date:</span>
            <span>{new Date(startDate).toLocaleDateString()}</span>
          </div>

          
          <div className="flex justify-between col-span-1">
            <span>Finish Date:</span>
            <span>{new Date(finishDate).toLocaleDateString()}</span>
          </div>

         
          <div className="flex justify-between col-span-1">
            <span>Price:</span>
            <span>€{price.toFixed(2)}</span>
          </div>

         
          <div className="flex justify-between col-span-1">
            <span>Quick Pickup:</span>
            <span>{quickPickup === "yes" ? "Available" : "Not Available"}</span>
          </div>
        </div>

       
        <button
          onClick={() => setShowModal(true)} 
          className="mt-4 bg-red-500 text-white font-bold py-2 px-4 rounded hover:bg-red-700 focus:outline-none focus:shadow-outline"
        >
          Delete Reservation
        </button>
      </div>

      
      {showModal && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
          <div className="bg-white p-6 rounded-lg shadow-lg w-full max-w-md">
            <h2 className="text-lg font-bold mb-4">Confirm Delete</h2>
            <p className="mb-4">Are you sure you want to delete the reservation for "{book.title}"?</p>

            <div className="flex justify-end">
              <button
                onClick={handleDelete}
                className="bg-red-500 text-white px-4 py-2 rounded mr-2"
              >
                Yes, Delete
              </button>
              <button
                onClick={() => setShowModal(false)}
                className="bg-gray-300 text-black px-4 py-2 rounded"
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ReservationCard;
