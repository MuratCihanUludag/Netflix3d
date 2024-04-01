import React from 'react'

function RegisterForm({handleOnClick}) {
  return (
    <form action="" className="form-register row g-4 p-2">
       <h4 className="text-white">Uye Ol</h4>
        <div className="form-group col-md-12">
            <label>Adiniz</label>
            <input type="text" name="" id="" className="form-control" />
        </div>

        <div className="form-group col-md-12">
            <label>Soyadiniz</label>
            <input type="text" name="" id="1" className="form-control" />
        </div>

        <div className="form-group col-12">
            <label>Email adresiniz</label>
            <input type="email" name="" id="2" className="form-control" />
        </div>

        <div className="form-group col-12">
            <label>Sifreniz</label>
            <input type="password" name="" id="3" className="form-control" />
        </div>

        <div className="form-group col-12">
            <label>Sifre Tekrari</label>
            <input type="password" name="" id="4" className="form-control" />
        </div>

        <div className="form-group col-md-12 mt-4">
            <button className="btn btn-danger w-100">Kayit Ol</button>
            <button onClick={()=>{handleOnClick(true)}} type='button' className='btn btn-danger my-3' >Geri Don</button>
        </div>
    </form> 
  )
}

export default RegisterForm