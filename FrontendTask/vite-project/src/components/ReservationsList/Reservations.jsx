import React, { useEffect, useState } from 'react'
import ReservationCard from './ReservationCard';

const Reservations = () => {
    const [reservations, setReservations] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
  
    useEffect(() => {
      fetchReservations(); 
    }, []);
  
    const fetchReservations = async () => {
      try {
        const response = await fetch('http://localhost:5149/api/reservations');
  
        if (!response.ok) {
          throw new Error('Failed to fetch reservations');
        }
  
        const data = await response.json();
        setReservations(data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
        setLoading(false);
      }
    };
  
    const handleDelete = (id) => {
     
      setReservations((prev) => prev.filter((reservation) => reservation.id !== id));
    };
  
    if (loading) {
      return <p>Loading reservations...</p>;
    }
  
    if (error) {
      return <p>Error: {error}</p>;
    }
  
    return (
      <div className="flex flex-wrap justify-center p-4 bg-gray-100">
        {reservations.map((reservation) => (
          <ReservationCard key={reservation.id} reservation={reservation} onDelete={handleDelete} />
        ))}
      </div>
    );
  };

export default Reservations