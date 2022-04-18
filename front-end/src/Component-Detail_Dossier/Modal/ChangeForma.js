import React  from 'react'
function ChangeForma({post ,setopen}) {
  function saveChange(){
    setopen(false)
}
  return (
    <div>
      <div className="modalBackgroundFichier">
      <img src="../image/close.png" className="closePageForma" onClick={saveChange} />
       <div className="imageFichier">
           <img src={post._file} className="bigimage"/>
       </div>
      </div>
    </div>
  )
}

export default ChangeForma
