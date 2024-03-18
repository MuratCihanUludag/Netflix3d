import React from 'react'
import Home from "../../Pages/Home"
import About from '../../Pages/About'
import { Route, Routes} from 'react-router-dom'
function ContainerRoute() {
  return (
    <section>
        <Routes>
            <Route path='/' element={<Home/>} />
            <Route path='/About' element={<About/>} />
        </Routes>
    </section>
  )
}

export default ContainerRoute