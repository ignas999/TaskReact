import React, { useState } from 'react'
import SearchBar from '../SearchBar/SearchBar';
import { ToastContainer } from 'react-toastify';
import Cardlist from '../Cardlist';

function Home() {

    const [filterText, setFilterText] = useState('');

  return (
    <div>
        <ToastContainer />
        <SearchBar filterText={filterText} onFilterChange ={setFilterText}/>
        <Cardlist filterText = {filterText} />
        
    </div>
  )
}

export default Home