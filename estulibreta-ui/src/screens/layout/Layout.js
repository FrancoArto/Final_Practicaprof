import React, { useState } from "react";
import UserInfo from "../user-info";
import { Router, Route, Switch } from "react-router";
import { createBrowserHistory } from "history";
import { Grid } from "@material-ui/core";
import SidePanel from "../../common/components/SidePanel";
import AppBar from "../../common/components/AppBar";

import "./layout.scss";

const history = createBrowserHistory();

const user = {
	firstName: "Franco",
	lastName: "Arto",
	role: "Alumno"
};

const Layout = () => {

	const [sidePanelVisible, setSidePanelVisible] = useState(false);

	return (
		<>
			<AppBar onMenuButtonClick={() => setSidePanelVisible(!sidePanelVisible)} user={user} />
			<Grid className="main-app-container" container>
				<SidePanel isVisible={sidePanelVisible} />
				<Grid item xs={12} md={9}>
					<Router history={history}>
						<Switch>
							<Route path="/">
								<UserInfo />
							</Route>
						</Switch>
					</Router>
				</Grid>
			</Grid>
		</>
	);
};

export default Layout;
