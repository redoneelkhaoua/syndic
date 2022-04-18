import React from "react";

export default function Dossier({ folder }) {

  var ImageUrl = "";
  if (folder.categoryNavigation.categoryName == "Vote") {
    ImageUrl = "../DossierImage/voting-box.png";
  } else if (folder.categoryNavigation.categoryName == "Payment") {
    ImageUrl = "../DossierImage/online-payment.png";
  } else if (folder.categoryNavigation.categoryName == "Urgent") {
    ImageUrl = "../DossierImage/error.png";
  } else {
    ImageUrl = "../DossierImage/folder.png";
  }
  var borderSt = "";
  if (folder.statusNavigation.statusName.toLowerCase() == "en attente") {
    borderSt = "red";
  } else if (folder.statusNavigation.statusName.toLowerCase() == "incomplet") {
    borderSt = "orange";
  } else if (folder.statusNavigation.statusName.toLowerCase()== "complet") {
    borderSt = "green";
  } else {
    borderSt = "blue";
  }
 
  function home(e) {
    var params = new URLSearchParams();
    params.append("id", folder.idCase); 
       window.location.href = "http://localhost:3000/DetailDossier?"+ params.toString() ;
   }

  return (
    <div className="note"  onClick={()=>{
      home();
    }
      }>
      <img src={ImageUrl} alt="" className="dossier-image" />
      <div id="statut" style={{ borderColor: borderSt }}>
        {folder.statusNavigation == null
          ? "Vide"
          : folder.statusNavigation.statusName}
      </div>
      <p>{folder.title}</p>
    </div>
  );
}
