import React, { useRef, Suspense } from "react";
import { Points, PointMaterial, Preload } from "@react-three/drei";
import { Canvas, useFrame } from "@react-three/fiber";
import * as random from "maath/random/dist/maath-random.esm";

const Start = (props) => {
  const sphere = random.inSphere(new Float32Array(5000), { radius: 1.2 });
  const ref = useRef();
  useFrame((state, delta) => {
    ref.current.rotation.x -= delta/10;
    ref.current.rotation.y -= delta/15;
  });

  return (
    <group rotation={[0, 0, Math.PI / 4]}>
      <Points ref={ref} positions={sphere} stride={3} frustumCulled {...props}>
        <PointMaterial
          transparent
          color="white"
          size={0.003}
          sizeAttenuation={true}
          depthWrite={false}
        />
      </Points>
    </group>
  );
};

function Starts() {
  return (
    <div className="position-absolute" style={{height:"100vh",zIndex:"-1" ,width:"100%",top:"0",left:"0"}}>
      <Canvas camera={{ position: [0, 0, 1] }}>
        <Suspense fallback={null}>
          <Start />
        </Suspense>
        <Preload all />
      </Canvas>
    </div>
  );
}

export default Starts;
