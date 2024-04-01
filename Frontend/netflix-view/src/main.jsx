import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './assets/css/index.css'
import { BrowserRouter } from 'react-router-dom'
import i18n from './assets/js/i18n.js'
import { ApiContextProvider } from './Context/ApiContext.jsx'

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <BrowserRouter>
        <ApiContextProvider>
            <App />
        </ApiContextProvider>
        </BrowserRouter>
    </React.StrictMode>
)
