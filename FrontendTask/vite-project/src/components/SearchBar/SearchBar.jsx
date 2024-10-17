import React from 'react';

function SearchBar({ filterText, onFilterChange }) {
  return (
    <form className="flex flex-col items-center justify-center mt-10"> 
      <label htmlFor="search" className="text-lg font-semibold mb-2">
        Search Books
      </label>
      <input
        id="search"
        type="text"
        value={filterText}
        onChange={(e) => onFilterChange(e.target.value)}
        placeholder="Search by title or year..."
        className="w-80 p-2 border-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
      />
    </form>
  );
}

export default SearchBar;
