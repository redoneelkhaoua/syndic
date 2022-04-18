import React from 'react';
import getCase from "../ApiDetailDossier/ApiPosts";

function CreePost({input , onInputChange,onClickSubmit }){

    return(
    <>
    <form onSubmit={onClickSubmit} >
       <div id="create">
        <input type="text" className='creeNote' 
        placeholder='Saisissez une note...' 
        onChange={onInputChange}
        value={input}
        />
        <div id="afficheNote">
            <button type="submit" id="logoAffiche" >
            Envoyer
            </button>
        </div>
        </div>
    </form>
    </>
    );
}
export default CreePost ;