import{ createBrowserRouter, createRoutesFromElements,Route,RouterProvider} from 'react-router-dom'
import Home from './components/BookDisplay/Home'
import NavBar from './components/NavBar'
import Reservations from './components/ReservationsList/Reservations'

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path='/' element={<NavBar/>}>
      <Route path="/" element={<Home/>} />
      <Route path="reservations" element={<Reservations/>} />
    </Route>
  )
);


function App() {

  return (
    <>

    <RouterProvider router={router}/>
    </>
  )
}

export default App
