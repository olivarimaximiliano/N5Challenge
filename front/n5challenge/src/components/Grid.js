import React, { useEffect } from "react";
import { DataGrid } from "@mui/x-data-grid";
import columns from "./GridColumns";
import useStyles from "./GridStyles";
import usePermissionData from "../services/GridHelpper";

function Grid() {
  const classes = useStyles();
  const [permissionsData, fetchPermissionsData] = usePermissionData();
  useEffect(() => {
    fetchPermissionsData();
  }, []);

  return (
    <div className={classes.gridContainer}>
     <div className={classes.gridContent}>
    <DataGrid 
      rows={permissionsData}
      columns={columns} 
      style={{ width: "100%" }} 
      />
        {!permissionsData.length??       
          <div>Error fetching data</div>
        }
      </div>
    </div>
  );
}

export default Grid;