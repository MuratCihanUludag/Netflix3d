import React from 'react'
import Points from '../Components/ThreeComponents/Points'
import Img from "../assets/image/tv.png"
import Mobil from "../assets/image/mobile-01.png"
function Home() {
    //Linkler ileriden apiden gelicektir simdilik on hazirlik ve tasarim icin buradan verilmistir    
  return (
    <div>
        <div className="position-ralative" style={{ height: "300vh" }}>
            <div className="position-sticky top-0">
                <Points />
            </div>
        </div>
        <hr />
        <div className="container">
            <div className='row align-items-center justify-content-between point-row m-5'>
                <div className='col-md-6 col-12'>
                    <h1>Televizyonunuzda izleyin</h1>
                    <p>Akıllı TV, PlayStation, Xbox, Chromecast, Apple TV, Blu-ray oynatıcılar ve daha fazlasında seyredin.</p>
                </div>
                <div className='col-md-6 col-12 position-relative'>
                    <img className='img-fluid '  src={Img} alt="" />
                    <video className='position-absolute top-50 start-50'  style={{transform:"translate(-50%,-50%)",zIndex:"-1",width: "67%"}}   autoPlay playsInline muted loop>
                        <source id='video' src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/video-tv-0819.m4v" type="video/mp4"/>
                    </video>
                </div>
            </div>
        </div>
        <hr />
        <div className='container'>
            <div className='row align-items-center justify-content-between m-5 '>
                <div className='col-md-6 col-12 position-relative'>
                    <img className='img-fluid'  src={Mobil} alt="" />
                    <div className='mobil-card-section-position position-absolute'>
                        <div className='d-flex justify-content-between align-items-center'>
                            <img className='mobil-picture'  src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/boxshot.png" alt="" />
                            <div className='text-start mobil-card-film-name '>
                                <p className='mb-0' >Stranger Things</p>
                                <p className='mb-0' style={{fontSize:"0.875rem"}}>İndiriliyor...</p>
                            </div>
                            <img className='download-img img-fluid' src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/download-icon.gif" alt="" />
                        </div>
                    </div>
                </div>
                <div className='col-md-6 col-12'>
                    <h1>Çevrimdışı izlemek için içerikleri indirin</h1>
                    <p>En sevdiğiniz içerikleri kolayca kaydedin ve her zaman izleyecek bir şeyleriniz olsun.</p>
                </div>
            </div>
        </div>
        <hr />
        <div className="container">
            <div className='row align-items-center justify-content-between point-row m-5'>
                <div className='col-md-6 col-12'>
                    <h1>İstediğiniz her yerde izleyin</h1>
                    <p>Telefonda, tablette, bilgisayarda, televizyonda sınırsız film ve dizi izleyin.</p>
                </div>
                <div className='col-md-6 col-12 position-relative'>
                    <img className='img-fluid '  src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/device-pile.png" alt="" />
                    <video className='position-absolute top-50 start-50'  style={{transform:"translate(-50%,-90%)",zIndex:"-1",width: "60%"}}   autoPlay playsInline muted loop>
                        <source id='video' src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/video-devices.m4v" type="video/mp4"/>
                    </video>
                </div>
            </div>
        </div>
        <hr />
        <div className='container'>
            <div className='row align-items-center justify-content-between m-5 '>
                <div className='col-md-6 col-12 position-relative'>
                <img className='img-fluid'  src="https://occ-0-4451-1432.1.nflxso.net/dnm/api/v6/19OhWN2dO19C9txTON9tvTFtefw/AAAABf9FUgiWN4GTIJexNEV8ZW_SPzGYmxKo7TaBfIoriNNfn85AMMEcvM61PwQ-NhPzGXz2qu53lDDcCuf0rH9FWOYBpvhUc2dQxIAQ.png?r=533" alt="" />
                </div>
                <div className='col-md-6 col-12'>
                    <h1>Çocuklarınız için profiller oluşturun</h1>
                    <p>En sevdiğiniz içerikleri kolayca kaydedin ve her zaman izleyecek bir şeyleriniz olsun.</p>
                </div>
            </div>
        </div>
        
    </div>
  )
}

export default Home