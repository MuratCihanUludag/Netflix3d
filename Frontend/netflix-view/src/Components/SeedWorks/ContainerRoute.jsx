import React from 'react'
import Home from "../../Pages/Home"
import About from '../../Pages/About'
import { Route, Routes} from 'react-router-dom'
import Auth from '../../Pages/Auth/Auth'
function ContainerRoute() {
  return (
    <section>
        <Routes>
            <Route path='/' element={<Home/>} />
            <Route path='/About' element={<About/>} />
            <Route path='/Auth' element={<Auth/>} />
        </Routes>
    </section>
  )
}

export default ContainerRoute