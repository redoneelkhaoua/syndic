import React , {useState } from "react";
import ModalFichier from "./Modal/ModalFichier"
function Fichier({ onChange ,onClick }){
    const [isopen, setopen] = useState(false);
    return(
    <>
  <div id="Fichie">
           <img src="../image/paper-clip (1).png" alt="" id="logoFichie" onClick={() => setopen(true)}/>
        </div>
        {isopen ? <ModalFichier setopen={setopen} onChange={onChange} onClick={onClick} /> : null}
    </>
    );
}
export default Fichier ;