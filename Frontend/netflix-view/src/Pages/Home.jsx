import React from 'react'
import Points from '../Components/ThreeComponents/Points'

function Home() {
  return (
    <div>
        <div className="position-ralative" style={{ height: "300vh" }}>
            <div className="position-sticky top-0">
                <Points />
            </div>
        </div>
        <div className="container">
            <div className="row point-row">
                <div className="col-12">
                    <h3 className="text-start mb-3" >İhtiyaçlarınıza Uygun Bir Plan</h3>
                </div>                     
            </div>
        </div>
    </div>
  )
}

export default Home