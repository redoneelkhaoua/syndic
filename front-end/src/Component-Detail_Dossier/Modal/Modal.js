import React from "react";
import "./Modal.css";
function ModalVote({ setopen ,nouveauChoix ,onChange ,onClick ,onSupprime ,onCreer ,onChoncheTitre}) {
  
  return (
    <>
      <div class="modalBackground1">
        <div className="modalContainerVote">
          <div className="Cree">
            <h1>Creer un Vote</h1>
          </div>
          <label className="TitreVote">Titre</label>
          <input type="text" class="inputTitreVote" onChange={onChoncheTitre}/>
          <br />
          <label className="ChoixVote">Choix</label>
          <input type="text" class="inputChoix" maxlength="20" onChange={onChange}/>
          <button className="btn-ajoute-choix" onClick={() =>{onClick() }}>Ajoute Choix</button>
          <br />
          <br />

          <img src="../image/close-femetr.png" className="closePage" onClick={() => {
            setopen(false);
             }} />

          <button className="btn-Creer-vote" onClick={() => {
            setopen(false);
             onCreer();}}>
            {" "}
            Creer{" "}
          </button>
          <div className="choixContainer">
              {nouveauChoix.map(function(n) {
                  return <div className="backgroundChoix">
                  <p className="choixP">{n.choice}</p>
                   <img src="../image/cancel.png" className="deletChoix"  onClick={() =>{onSupprime(n) }}/>
                 </div>
              })}  
          </div>
         
        </div>
      </div>
    </>
  );
}
export default ModalVote;