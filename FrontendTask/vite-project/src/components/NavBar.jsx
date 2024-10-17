import React from 'react'
import { NavLink, Outlet } from 'react-router-dom'

function NavBar() {
  return (
    <>
      <header className="bg-gray-200 w-full">
        <nav className="flex justify-between items-center p-4">
          <div className="flex space-x-4">
            <NavLink
              to="/"
              className="text-gray-700 hover:text-gray-900"
              activeClassName="font-bold" 
            >
              Home
            </NavLink>

          </div>
          <div>
            
          <NavLink
              to="/reservations"
              className="text-gray-700 hover:text-gray-900"
              activeClassName="font-bold"
            >
              Reservations
            </NavLink>
          </div>
        </nav>
      </header>

    <main>
        <Outlet/>
    </main>
    </>
  )
}

export default NavBar