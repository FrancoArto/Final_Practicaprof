import React from "react";
import { Table, TableBody, TableRow, TableCell } from "@material-ui/core";

import labels from "../../utils/labels.json";

const UserTable = ({ user: { approvedSignatures, birthDate, career, document, fileNumber, firstName, lastName } }) => (
	<Table>
		<TableBody>
			<TableRow>
				<TableCell>{labels["app.userInfo.fullName"]}:</TableCell>
				<TableCell>{`${lastName}, ${firstName}`}</TableCell>
			</TableRow>
			<TableRow>
				<TableCell>{labels["app.userInfo.birthDate"]}:</TableCell>
				<TableCell>{birthDate}</TableCell>
			</TableRow>
			<TableRow>
				<TableCell>{labels["app.userInfo.document"]}:</TableCell>
				<TableCell>{document}</TableCell>
			</TableRow>
			<TableRow>
				<TableCell>{labels["app.userInfo.file"]} n°:</TableCell>
				<TableCell>{fileNumber}</TableCell>
			</TableRow>
			<TableRow>
				<TableCell>{labels["app.userInfo.career"]}:</TableCell>
				<TableCell>{career}</TableCell>
			</TableRow>
			<TableRow>
				<TableCell>{labels["app.userInfo.approvedSignatures"]}:</TableCell>
				<TableCell>{approvedSignatures}</TableCell>
			</TableRow>
		</TableBody>
	</Table>
);
export default UserTable;
