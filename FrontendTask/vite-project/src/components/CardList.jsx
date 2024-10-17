import React, { useState, useEffect } from 'react';
import Card from './Card';
import ReservationForm from './ReservationForm/Reservationform';

const Cardlist = ({ filterText }) => {
    const [books, setBooks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [selectedBook, setSelectedBook] = useState(null); 

    useEffect(() => {
        const fetchBooks = async () => {
            try {
                const response = await fetch('http://localhost:5149/api/Books');
                
                if (!response.ok) {
                    throw new Error('Failed to fetch books');
                }
                
                const data = await response.json();
                setBooks(data);
                setLoading(false);
            } catch (error) {
                setError(error.message);
                setLoading(false);
            }
        };

        fetchBooks();
    }, []);

    const handleReservationSubmit = (reservationDetails) => {
        console.log('Reservation submitted:', reservationDetails);
        setSelectedBook(null); 
    };

    const handleReserveClick = (book) => {
        setSelectedBook(book);
    };

    const handleCloseModal = () => {
        setSelectedBook(null); 
    };

   
    const filteredBooks = books.filter(book => {
        const lowerCaseFilter = filterText.toLowerCase();
        return (
            book.title.toLowerCase().includes(lowerCaseFilter) || 
            book.year.toString().includes(lowerCaseFilter)
        );
    });

    if (loading) {
        return <p>Loading books...</p>;
    }

    if (error) {
        return <p>Error: {error}</p>;
    }

    return (
        <div className="relative">
          {filteredBooks.length === 0 ? (
            <p className="text-center text-lg text-gray-500 mt-10">No books found matching your search.</p>
          ) : (
            <div className="flex flex-wrap">
              {filteredBooks.map((book) => (
                <div key={book.id} className="w-1/2 p-2">
                  <Card
                    book={book}
                    title={book.title}
                    author={book.author}
                    year={book.year}
                    picture={book.picture}
                    onReserveClick={() => handleReserveClick(book)} 
                  />
                </div>
              ))}
            </div>
          )}
    
          {selectedBook && (
            <ReservationForm
              book={selectedBook}
              onSubmit={handleReservationSubmit}
              onClose={handleCloseModal}
            />
          )}
        </div>
    );
};

export default Cardlist;
