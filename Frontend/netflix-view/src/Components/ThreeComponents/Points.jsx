import React, { useEffect, useRef, useState } from "react";
import { Canvas, useFrame } from "@react-three/fiber";
import { useTranslation } from "react-i18next";



const CreatePoint = ({ position, size, color }) => {
    let deltaZ = window.scrollY * 0.04 < 3 ? 3 : window.scrollY * 0.04;
    const ref = useRef();
    const opacityRef = useRef(0);
   
    const [speed, setSpeed] = useState(deltaZ);
    const [scale, setScale] = useState(1);
    const [opacity, setOpacity] = useState(1);
  
    let homeTitle = document.querySelector(".home-title");
    let btnBlueShow = document.querySelector(".btn-blue");
  
    homeTitle.style.transform = ` translate(-50%, -50%) scale(${scale})`;
    homeTitle.style.opacity = `${opacity}`;
    homeTitle.style.opacity = opacity.toString();

    if (parseFloat(homeTitle.style.opacity) < 0) {
      homeTitle.style.display = "none";
    } else {
      homeTitle.style.display = "block";
    }
    useEffect(() => {
      const handleWhell = () => {
        deltaZ = window.scrollY * 0.05;
  
        let newSpeed = deltaZ;
  
        if (newSpeed < 3) newSpeed = 3;
        if (newSpeed > 60) newSpeed = 60;
        if (window.scrollY > 1) {
          btnBlueShow.classList.add("close");
          btnBlueShow.classList.remove("show");
        } else {
          btnBlueShow.classList.remove("close");
          btnBlueShow.classList.add("show");
        }
  
        setSpeed(newSpeed);
        setScale(window.scrollY * 0.0012 + 1);
        setOpacity(window.scrollY * -0.0015 + 1);
      };
      window.addEventListener("scroll", handleWhell);
      return () => {
        window.removeEventListener("scroll", handleWhell);
      };
    }, [speed]);
    useFrame((state, delta) => {
      opacityRef.current += delta;
      ref.current.position.z += delta * speed;
  
      if (ref.current.position.z > 5) {
        ref.current.position.z += -30;
        opacityRef.current = 0.2;
      }
      if (ref.current.position.z > -15) {
        opacityRef.current = 1;
      }
      ref.current.material.opacity = opacityRef.current;
    });
    return (
      <mesh position={position} ref={ref}>
        <sphereGeometry args={size} />
        <meshStandardMaterial color={color} transparent />
      </mesh>
    );
  };




  const CreatePoints = () => {
    const [arr] = useState(() => {
      let a = [];
      for (let i = 0; i < 501; i++) {
        a.push(i);
      }
      return a;
    });
    return (
      <>
        {arr.map((i) => (
          <CreatePoint
            key={i}
            position={[
              Math.random() * 80 - 40,
              Math.random() * 60 - 30,
              Math.random() * 30 - 15,
            ]}
            color={i % 3 === 0 ? "#BFFFCA" : i % 5 === 0 ? "#0079F2" : "white"}
            size={[0.12, 30, 30]}
          />
        ))}
      </>
    );
  };

function Points() {
  const {t,i18n} = useTranslation();
    const WindowScroll = (num) =>{
        window.scrollTo({
            top:num,
            behavior:"smooth"
        })
    }
    const ButtonClick = () =>{
        const targetClass = document.querySelector(".point-row")
        const targerOffset = targetClass.offsetTop;
        WindowScroll(800);
        setTimeout(()=>{
            WindowScroll(targerOffset);
        },800)
        
    }
  return (
    <div className='points' style={{height:"100vh"}}>
        <Canvas>
            <ambientLight/>
            {CreatePoints()}
        </Canvas>
        <div className={`home-title text-center`}>
            <h1 >{t("Point_h_text")}</h1>
              <p className="w-75 mx-auto" dangerouslySetInnerHTML={{ __html: t('Point_p_text', { returnObjects: true }) }} />
            <button onClick={ButtonClick} className={`btn btn-blue show`}>
              {t("Point_button_text")}
            </button>
      </div>
    </div>
  )
}

export default Points