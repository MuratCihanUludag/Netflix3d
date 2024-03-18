import React from 'react'
import Points from '../Components/ThreeComponents/Points'
import Img from "../assets/image/tv.png"
import Mobil from "../assets/image/mobile-01.png"
import Child from "../assets/image/Childrean.png"
import Gift from "../assets/gift/download-icon.gif"
import BoxShot from "../assets/image/boxshot.png"
import { useTranslation } from 'react-i18next'
import HomeAccordion from "../Components/Accordions/HomeAccordion"
import HomeEmailForm from "../Components/Forms/HomeEmailForm"
function Home() {
    const {t} = useTranslation()
    //Linkler ileriden apiden gelicektir simdilik on hazirlik ve tasarim icin buradan verilmistir    
  return (
    <div>
        <div className="position-ralative" style={{ height: "300vh" }}>
            <div className="position-sticky top-0">
                <Points />
            </div>
        </div>
        <hr />
        <div className="container container-1">
            <div className='row align-items-center justify-content-between point-row m-md-5'>
                <div className='col-lg-6 col-12 text-description text-center text-lg-start'>
                    <h1>{t("Home_Container_1_h_text")}</h1>
                    <p>{t("Home_Container_1_p_text")}</p>
                </div>
                <div className='col-lg-6 col-12 position-relative text-center'>
                    <img className='img-fluid'  src={Img} alt="" />
                    <video className='position-absolute top-50 start-50'  style={{transform:"translate(-50%,-50%)",zIndex:"-1",width: "67%"}}   autoPlay playsInline muted loop>
                        <source id='video' src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/video-tv-0819.m4v" type="video/mp4"/>
                    </video>
                </div>
            </div>
        </div>
        <hr />
        <div className='container container-2'>
            <div className='row align-items-center justify-content-between m-md-5 '>
                <div className='col-lg-6 col-12 position-relative text-center'>
                    <img className='img-fluid'    src={Mobil} alt="" />
                    <div className='mobil-card-section-position row gx-3 align-items-center'>
                            <div className='col-4 '>
                                <img className='img-fluid mobil-picture' src={BoxShot} alt="" />
                            </div>
                            <div className='col-4 text-start justify-content-between flex-colum'>
                                <p className='mb-2'>Stranger Things</p>
                                <p className='mb-0' style={{fontSize:"0.675rem"}}>İndiriliyor...</p>
                            </div>
                            <div className='col-4 '>
                                <img className='download-img img-fluid' src={Gift} alt="" />
                            </div>
                    </div>
                </div>
                <div className='col-lg-6 col-12 text-description text-center text-lg-start'>
                    <h1>{t("Home_Container_2_h_text")}</h1>
                    <p>{t("Home_Container_2_p_text")}</p>
                </div>
            </div>
        </div>
        <hr />
        <div className="container container-3">
            <div className='row align-items-center justify-content-between point-row m-md-5'>
                <div className='col-lg-6 col-12 text-description text-center text-lg-start'>
                    <h1>{t("Home_Container_3_h_text")}</h1>
                    <p>{t("Home_Container_3_p_text")}</p>
                </div>
                <div className='col-lg-6 col-12 position-relative'>
                    <img className='img-fluid '  src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/device-pile.png" alt="" />
                    <video className='position-absolute top-50 start-50'  style={{transform:"translate(-50%,-90%)",zIndex:"-1",width: "60%"}}   autoPlay playsInline muted loop>
                        <source id='video' src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/video-devices.m4v" type="video/mp4"/>
                    </video>
                </div>
            </div>
        </div>
        <hr />
        <div className='container container-4'>
            <div className='row align-items-center justify-content-between m-md-5 '>
                <div className='col-lg-6 col-12 position-relative'>
                    <img className='img-fluid'  src={Child} alt="" />
                </div>
                <div className='col-lg-6 col-12 text-description text-center text-lg-start'>
                    <h1>{t("Home_Container_4_h_text")}</h1>
                    <p>{t("Home_Container_4_p_text")}</p>
                </div>
            </div>
        </div>
        <hr />
        <div className='container'>
           <HomeAccordion t={t}/>
        </div>
        <hr />
        <div className='container'>
            <HomeEmailForm t={t}/>
        </div>
    </div>
  )
}

export default Home