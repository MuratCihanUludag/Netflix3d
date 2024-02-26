import React from 'react'
import Home from "../../Pages/Home"
import { Routes,Route } from 'react-router-dom'
function Container() {
  return (
    <div>
        <Routes>
            <Route path='/' element={<Home/>} />
        </Routes>
    </div>
  )
}

export default Container