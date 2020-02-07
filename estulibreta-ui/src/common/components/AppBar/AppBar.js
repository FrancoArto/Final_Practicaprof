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

const AppBar = ({ isLoggedIn, user: { firstName , lastName , role } }) => {
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
						>
							<MenuIcon />
						</IconButton>
						<Typography variant="h6" className="toolbar__title">
							{`${firstName} ${lastName} - ${role}`}
						</Typography>
					</Hidden>
          <Hidden smDown>
            <CardMedia>LOGO</CardMedia>
          </Hidden>
					{isLoggedIn && (
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
									horizontal: "middle"
								}}
								keepMounted
								transformOrigin={{
									vertical: "bottom",
									horizontal: "middle"
								}}
								open={open}
								onClose={handleClose}
							>
								<MenuItem onClick={handleClose}>
									{labels["app.common.logout"]}
								</MenuItem>
							</Menu>
						</div>
					)}
				</Toolbar>
			</AppBarComponent>
		</div>
	);
};

//connected component
export default AppBar;
