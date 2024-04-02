import React, { useRef } from 'react'
import axios from 'axios'

function RegisterForm({handleOnClick}) {
    const formRef = useRef();
    const Submit = async (e)=>{
        e.preventDefault();    

        try {
            const response = await axios.post("https://localhost:7091/api/register",
            Object.fromEntries(new FormData(formRef.current).entries()))
            alert(response.data)
        } catch (error) {
            const Response ={
                status:error.response.status,
                message:error.response.data
            }
            alert(`Status Code:${Response.status}\N Message:${Response.message}`)
        }
    }
  return (
    <form ref={formRef} onSubmit={Submit} className="form-register row g-4 p-2">
       <h4 className="text-white">Uye Ol</h4>
        <div className="form-group col-md-12">
            <label>Adiniz</label>
            <input type="text" name="name" id="0" required  className="form-control" />
        </div>

        <div className="form-group col-md-12">
            <label>Soyadiniz</label>
            <input type="text" name="surname" id="1" required className="form-control" />
        </div>

        <div className="form-group col-12">
            <label>Email adresiniz</label>
            <input type="email" name="email" id="2" required className="form-control" />
        </div>

        <div className="form-group col-12">
            <label>Sifreniz</label>
            <input type="password" name="password" id="3" required className="form-control" />
        </div>

        {/* <div className="form-group col-12">
            <label>Sifre Tekrari</label>
            <input type="password" name="" id="4" className="form-control" />
        </div> */}

        <div className="form-group col-md-12 mt-4">
            <button className="btn btn-danger w-100">Kayit Ol</button>
            <button onClick={()=>{handleOnClick(true)}} type='button' className='btn btn-info my-3' >Geri Don</button>
        </div>
    </form> 
  )
}

export default RegisterForm