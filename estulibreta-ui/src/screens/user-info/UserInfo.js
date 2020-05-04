import React from "react";
import {
	Grid,
	CardMedia,
} from "@material-ui/core";
import UserTable from "../../common/components/UserTable";


const UserInfo = ({ user }) => (
	<Grid container className="screen--user-info" direction="column">
		<CardMedia className="user-picture" />
		<UserTable user={user} />
	</Grid>
);

export default UserInfo;
