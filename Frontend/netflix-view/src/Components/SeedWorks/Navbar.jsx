import React from "react";
import { NavLink } from "react-router-dom";

import { useTranslation} from "react-i18next";

function Navbar() {
    const {t,i18n} = useTranslation();

    const languageHandle = async lang=>{
        await i18n.changeLanguage(lang.target.value)
    }
    
    let languageSelected = localStorage.getItem("i18nextLng");

  return (
    
    <header className="header-container">
        <div className="navbar-blur"></div>
        <nav className="navbar navbar-expand-lg">
            <div className="container-fluid ">
                <NavLink className="navbar-brand text-danger netflix-text" to="/"> <span className="text-danger">Netflix</span> </NavLink>
                <a className=""  href="#"> </a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent" style={{flexGrow:"revert"}}>
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item me-3 my-3 my-lg-0">
                            <select value={languageSelected} onChange={languageHandle} className="form-select select-language" aria-label="Default select example">
                                <option value="tr">Türkçe</option>
                                <option value="en">English</option>
                            </select>
                        </li>
                        <li className="nav-item"> <NavLink className=" btn btn-danger" to="/Auth" >{t("Login")}</NavLink> </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
  );
}
export default Navbar;
