import React  from "react";
function Statut({ Statuts ,onChange ,cases }) {
   
  return (
    <>
      <form>
        <select aria-label="State" className="comboST" onChange={onChange}>
          <option value="Select" >Status</option>
          {Statuts.map((st) => {
            return <option value={st.Statut}>{st.statusName} </option>;
          })}
        </select>
      </form>
      <div id="titleDT"> 
            <p>{cases.title}</p>
      </div>
    </>
  );
}
export default Statut;
