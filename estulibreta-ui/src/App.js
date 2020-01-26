import React from "react";
import Login from "./screens/login";
import { Grid } from "@material-ui/core";

import './App.scss';

const App = () => {
  return (
    <Grid container className="app">
      <Login />
    </Grid>
  );
};

export default App;
