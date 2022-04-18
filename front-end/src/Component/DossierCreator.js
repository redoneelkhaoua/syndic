import React, { useState } from "react";
import DossierModal from "./DossierModal";
export default function DossierCreator({
  Statut,
  onChange,
  onClick,
  Categorie,
  onChangeCategory,
  onClickCategory,
  OnSaveStatut,
  OnSaveCategory,
  OnSaveTitre,
  OnsaveDescription,
  onClickCreeDossier,
}) {
  const [isopen, setopen] = useState(false);
  return (
    <>
      <div className="Dossier-Creator">
        <p id="LD">Les dossiers</p>
      </div>
      <div className="Button-CD" onClick={() => setopen(true)}>
          <img src="../Media/plus.png" alt="" />
          <p>Créer un dossier</p>
        </div>
      {isopen ? (
        <DossierModal
          isopen={isopen}
          setopen={setopen}
          Statut={Statut}
          onChange={onChange}
          onClick={onClick}
          Categorie={Categorie}
          onChangeCategory={onChangeCategory}
          onClickCategory={onClickCategory}
          OnSaveStatut={OnSaveStatut}
          OnSaveCategory={OnSaveCategory}
          OnSaveTitre={OnSaveTitre}
          OnsaveDescription={OnsaveDescription}
          onClickCreeDossier={onClickCreeDossier}
        />
      ) : null}
    </>
  );
}
