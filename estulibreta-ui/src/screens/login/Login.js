import React from "react";
import { Grid, TextField, Button } from "@material-ui/core";
import { useFormik } from "formik";

import labels from "../../common/utils/labels.json";
import "./login.scss";

const Login = () => {
  const initialValues = {
    password: "",
    username: ""
  };

  const formik = useFormik({
    initialValues,
    onReset: (_values, { resetForm }) => resetForm({ values: initialValues }),
    onSubmit: (values, { resetForm }) => {
      alert(JSON.stringify(values));
      resetForm({ values: initialValues });
    }
  });

  return (
    <Grid container className="login-container" xs={10} sm={6} lg={4}>
      <form onSubmit={formik.handleSubmit}>
        <Grid item xs={12} className="field-container">
          <TextField
            className="field-container__input"
            fullWidth
            id="username"
            label={labels["app.login.username"]}
            name="username"
            onChange={formik.handleChange}
          />
        </Grid>
        <Grid item xs={12} className="field-container">
          <TextField
            className="field-container__input"
            fullWidth
            id="password"
            label={labels["app.login.password"]}
            name="password"
            onChange={formik.handleChange}
            type="password"
          />
        </Grid>
        <Grid item xs={12} className="buttons-container">
          <Button
            className="buttons-container__button"
            color="primary"
            type="reset"
            variant="text"
          >
            {labels["app.common.clear"]}
          </Button>
          <Button
            color="primary"
            className="buttons-container__button"
            type="submit"
            variant="contained"
          >
            {labels["app.login.login"]}
          </Button>
        </Grid>
      </form>
    </Grid>
  );
};

export default Login;
