import { createContext } from "react";

const ApiContext = createContext();
export const ApiContextProvider = ({children})=>{
    const values ={

    }
    return <ApiContext.Provider value={values}>{children }</ApiContext.Provider>
} 
export default ApiContext