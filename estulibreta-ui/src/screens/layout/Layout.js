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
	approvedSignatures: '5',
	career: 'Analista de sistemas',
	document: '38497299',
	fileNumber: '123456',
	role: "Alumno",
	birthDate: '09/01/1994',
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
								<UserInfo user={user} />
							</Route>
						</Switch>
					</Router>
				</Grid>
			</Grid>
		</>
	);
};

export default Layout;
