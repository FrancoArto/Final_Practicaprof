import React, { useState } from "react";
import AppBarComponent from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import AccountCircle from "@material-ui/icons/AccountCircle";
import MenuItem from "@material-ui/core/MenuItem";
import Menu from "@material-ui/core/Menu";

import labels from "../../utils/labels.json";

import "./app-bar.scss";
import { Hidden, CardMedia } from "@material-ui/core";
import { APP_LOGO } from "../../utils/constants";

const AppBar = ({ onMenuButtonClick, user: { firstName, lastName, role } }) => {
	const [anchorEl, setAnchorEl] = useState(null);
	const open = Boolean(anchorEl);

	const handleMenu = event => {
		setAnchorEl(event.currentTarget);
	};

	const handleClose = () => {
		setAnchorEl(null);
	};

	return (
		<div className="app-bar">
			<AppBarComponent position="static">
				<Toolbar className="toolbar">
					<Hidden mdUp>
						<IconButton
							edge="start"
							className="toolbar__menu-button"
							color="inherit"
							aria-label="menu"
							onClick={onMenuButtonClick}
						>
							<MenuIcon />
						</IconButton>
						<Typography variant="h6" className="toolbar__title">
							{`${firstName} ${lastName} - ${role}`}
						</Typography>
					</Hidden>
					<Hidden smDown>
						<CardMedia className="app-logo" component="img" src={APP_LOGO} />
					</Hidden>
					<div className="toolbar__user-button">
						<IconButton
							aria-label="account of current user"
							aria-controls="menu-appbar"
							aria-haspopup="true"
							onClick={handleMenu}
							color="inherit"
						>
							<AccountCircle />
						</IconButton>
						<Menu
							id="menu-appbar"
							anchorEl={anchorEl}
							anchorOrigin={{
								vertical: "bottom",
								horizontal: "left"
							}}
							keepMounted
							transformOrigin={{
								vertical: "bottom",
								horizontal: "left"
							}}
							open={open}
							onClose={handleClose}
						>
							<MenuItem onClick={handleClose}>
								{labels["app.common.logout"]}
							</MenuItem>
						</Menu>
					</div>
				</Toolbar>
			</AppBarComponent>
		</div>
	);
};

//connected component
export default AppBar;
