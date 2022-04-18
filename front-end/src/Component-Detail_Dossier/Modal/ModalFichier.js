import React from "react";
import "./Modal.css";
function ModalFichier({ setopen, onChange, onClick  }) {
 
  function onClickSave(e) {
    setopen(false);
  }
  return (
    <>
      <div className="modalBackground1">
        <div className="modalContainer2">
          <img
            src="../image/close-femetr.png"
            className="closeFielPage"
            onClick={() => {
              setopen(false);
            }}
          />
          <div className="Cree">
            <h1>Ajouter un Files</h1>
          </div>
          <label className="Titre2">Files</label>
          <input type="file" class="inputFiels" onChange={onChange} />
          <button
            className="btn-Creer2"
            onClick={() => {
              onClickSave();
              onClick();
            }}
          >
            Ajoute
          </button>
        </div>
      </div>
    </>
  );
}

export default ModalFichier;
