import React from "react";
import Login from "./screens/login";
import { Grid } from "@material-ui/core";
import Layout from "./screens/layout";

import "./App.scss";

const App = ({ athToken }) => {
	return (
		<>
			<Grid container className="app">
				{athToken ? <Layout /> : <Login />}
			</Grid>
		</>
	);
};

export default App;
