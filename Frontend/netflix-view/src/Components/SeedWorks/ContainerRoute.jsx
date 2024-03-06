import React from 'react'
import Home from "../../Pages/Home"
import { Routes,Route } from 'react-router-dom'
function ContainerRoute() {
  return (
    <section>
        <Routes>
            <Route path='/' element={<Home/>} />
        </Routes>
    </section>
  )
}

export default ContainerRoute