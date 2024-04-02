import React, { Suspense, useEffect, useRef, useState } from "react";
import { Canvas } from "@react-three/fiber";
import { OrbitControls, useGLTF } from "@react-three/drei";

const NetflixCanvas = () => {
  const netflixLogo = useGLTF("./NetflixLogo/scene.gltf");
  const ref = useRef();
  return (
    <mesh ref={ref} rotation={[Math.PI / -2, 0, 0]}>
      <primitive object={netflixLogo.scene} scale={12} />
    </mesh>
  );
};

function Netflix() {
    const orbitControls = useRef()
    useEffect(()=>{
        console.log(orbitControls.current)
    })
  return (
    <Canvas
      shadows
      frameloop="demand"
      gl={{ preserveDrawingBuffer: true }}
      camera={{ fov: 45, near: 0.01, far: 200, position: [-1, 0, 12] }}
      style={{ width: "150px", height: "75px" }}
    >
      <Suspense fallback="...">
        <OrbitControls
          enableZoom={false}
      
          minDistance={10} 
          maxDistance={15} 
          ref={orbitControls}
        />{" "}
        <NetflixCanvas />
      </Suspense>
    </Canvas>
  );
}

export default Netflix;
