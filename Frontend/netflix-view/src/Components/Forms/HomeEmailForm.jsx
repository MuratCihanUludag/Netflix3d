import React from 'react'
import { useRef } from 'react'

function HomeEmailForm({t}) {
    const formRef = useRef();
    const  SubmitEmail= ()=>{
        var formData =  Object.fromEntries(new FormData(formRef.current).entries());
        alert(`${formData.email} mail gonderilmistir`)
    }
  return (
    <>
        <form  className='my-3' action="" ref={formRef}>
            <h6 className='mb-4'>{t("Home-Email-Form-h6")}</h6>
            <div className="row g-3 align-items-center">
                <div className="col-8">
                    <input type="email" required  name='email' className="form-control" placeholder={t("Email-placeholder")} />
                </div>
                <div className="col-4">
                    <button type='button' className='btn btn-danger' onClick={SubmitEmail}>{t("Start")}</button>
                </div>
            </div>
        </form>
    </>
  )
}

export default HomeEmailForm