import React from "react";
import App from "./Component-Detail_Dossier/App";
import DossierApp from "./Component/DossierApp";
import { BrowserRouter, Routes, Route } from "react-router-dom";

export default function AppGestionDeSyndic() {
  return (
    <BrowserRouter>
    <Routes>
      <Route exact path="/" element={<DossierApp />} />
      <Route path="/DetailDossier" element={<App />} />
    </Routes>
  </BrowserRouter>
  );
}
