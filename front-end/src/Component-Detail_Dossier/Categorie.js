import React from "react";

function Categorie({ Categories, onchange }) {
  return (
    <>
      <form>
        <select aria-label="State" id="comboCategories" onChange={onchange}>
          <option value="Select" >Categories</option>
          {Categories.map((Categorie) => {
            return <option>{Categorie.categoryName}</option>;
          })}
        </select>
      </form>
    </>
  );
}
export default Categorie;
