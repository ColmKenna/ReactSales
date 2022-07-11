import React from 'react';
import Layout from "./Components/Layout";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from "./Components/Home";
import {FetchProducts} from "./Components/FetchProducts";
import {FetchLocations} from "./Components/FetchLocations";
import {FetchAll} from "./Components/FetchAll";



function App(){
    return (
        <BrowserRouter>
        <Layout>
            <Routes>
                <Route path='/'  element={<Home/>} />
                <Route path='/fetch-products' element={<FetchProducts/>} />
                <Route path='/fetch-locations' element={<FetchLocations/>} />
                <Route path='/fetch-all' element={<FetchAll/>} />
            </Routes>
        </Layout>
        </BrowserRouter>);
}



export default App;