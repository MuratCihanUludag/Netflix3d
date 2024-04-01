import React, { useRef } from 'react'
import axios from 'axios'

function LoginForm({handleOnClick}) {
    const formRef = useRef();
    
    const Submit = async (e)=>{
        e.preventDefault();    
       
            try {
            const response = await axios.post("https://localhost:7091/api/Login",
            Object.fromEntries(new FormData(formRef.current).entries())
            );
            sessionStorage.setItem("key",response.data.token)
            console.log(response.data);
        } catch (error) {
            const Response ={
                status:error.response.status,
                message:error.response.data
            }
            console.error(Response);
        }
    }
    console.log(sessionStorage.getItem("key"))
  return (
    <form ref={formRef} onSubmit={Submit} className="form-login row g-4 p-2"> 
       <h4 className="text-white">Oturum Ac</h4>
        <div className="form-group col-12">
            <label>Email </label>
            <input type="email" name="email" id="6" className="form-control" />
        </div>
        <div className="form-group col-12">
            <label>Sifre</label>
            <input type="password" name="password" id="7" className="form-control" />
        </div>
        <div className="form-group col-12">
            <button  type='submit' className=" w-100 btn btn-danger">Giris Yap</button>
        </div>
        <div className="form-group col-12">
            <h5 className='text-center'>VEYA</h5>
        </div>
        <div className="form-group col-12">
            <button onClick={()=>{handleOnClick(false)}} type='button'  className='btn btn-warning w-100 mb-3' >Uye Ol</button>
        </div>
    </form>
  )
}

export default LoginForm