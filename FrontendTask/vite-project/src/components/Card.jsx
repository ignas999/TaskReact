
import React from 'react';

const Card = ({ title, author, year, picture, onReserveClick }) => {
  return (
    <div className="p-6 flex flex-col rounded-lg bg-white text-surface shadow-secondary-1 dark:bg-surface-dark dark:text-white md:max-w-xl md:flex-row">
      <img
        src={picture}
        alt={`${title} cover`}
        className="h-96 w-full rounded-t-lg object-cover md:h-auto md:w-48 md:!rounded-none md:!rounded-s-lg"
      />
      <div className="flex flex-col justify-between p-6 md:flex-1"> 
        <h5 className="mb-2 text-xl font-medium">{title}</h5>
        <p className="mb-4 text-base">Author: {author}</p>
        <p className="mb-4 text-base">Year: {year}</p>
        <button
          className="bg-blue-500 text-white px-4 py-2 rounded"
          onClick={onReserveClick}
        >
          Add Reservation
        </button>
      </div>
    </div>
  );
  
};

export default Card;
