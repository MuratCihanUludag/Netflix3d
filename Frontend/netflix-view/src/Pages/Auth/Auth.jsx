import React, { useState } from "react";
import Stars from "../../Components/Canvas/Starts"
import LoginForm from "../../Components/Forms/LoginForm";
import RegisterForm from "../../Components/Forms/RegisterForm";
function Auth() {

    const [type, setType] = useState(true);
    
    const handleOnClick = (res) => {
        console.log(res)
        setType(res);
}


return (
    <div>
        <div className="auth-img"></div>
      {/* <Starts /> */}
        <div className="container position-relative" style={{ height: "100vh" }}>
            <div className="row">
                <div className={`col-md-8 col-12 mx-auto py-5 auth-form ${type != true ? "singUp":"singIn"}`}>
                    <div className="row">
                        <div className="col-12 auth-content">
                            <LoginForm handleOnClick={handleOnClick} />
                            <RegisterForm handleOnClick={handleOnClick} />                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  );
}

export default Auth;
