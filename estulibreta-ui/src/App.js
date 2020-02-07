import React from "react";
import Login from "./screens/login";
import { Grid } from "@material-ui/core";

import "./App.scss";
import AppBar from "./common/components/AppBar";

const user = {
	firstName: "Franco",
	lastName: "Arto",
	role: "Alumno"
};

const App = () => {
	return (
		<>
			<AppBar isLoggedIn={false} user={user} />
			<Grid container className="app">
				<Login />
			</Grid>
		</>
	);
};

export default App;
