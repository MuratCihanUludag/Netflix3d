import Navbar from './Components/SeedWorks/Navbar'
import Footer from './Components/SeedWorks/Footer'
import ContainerRoute from './Components/SeedWorks/ContainerRoute'
import "./assets/css/App.css"
import "./assets/js/bootstrap.bundle.min.js"
function App() {

  return (
    <div>
        <Navbar/>         { /*=== Header ===*/}
        <ContainerRoute/> { /*=== Routes ===*/}
        <Footer/>         { /*=== Footer ===*/}
    </div>
  )
}

export default App
