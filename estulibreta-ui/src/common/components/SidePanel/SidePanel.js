import React from "react";
import {
	Grid,
	List,
	ListItem,
	ListItemIcon,
	ListItemText,
	Slide,
	useMediaQuery
} from "@material-ui/core";
import { BorderClear, LibraryBooks, Person } from "@material-ui/icons";

import labels from "../../utils/labels.json";

const SidePanel = ({ showMyCodes, isVisible }) => {

	const isMobile = useMediaQuery(theme => theme.breakpoints.down('sm'));
	
	return (
		<Slide direction="right" in={isMobile ? isVisible : true} mountOnEnter unmountOnExit>
			<Grid item md={3} className="side-panel">
				<List component="nav">
					<ListItem button>
						<ListItemIcon>
							<Person />
						</ListItemIcon>
						<ListItemText primary={labels["app.sidePanel.myData"]} />
					</ListItem>
					<ListItem button>
						<ListItemIcon>
							<LibraryBooks />
							<ListItemText primary={labels["app.sidePanel.mySubjects"]} />
						</ListItemIcon>
					</ListItem>
					{showMyCodes && (
						<ListItem button>
							<ListItemIcon>
								<BorderClear />
								<ListItemText primary={labels["app.sidePanel.myCodes"]} />
							</ListItemIcon>
						</ListItem>
					)}
				</List>
			</Grid>
		</Slide>
	);
};

export default SidePanel;
