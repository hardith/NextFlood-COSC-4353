import React, { useState } from "react";
import Grid from "@mui/material/Grid";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import RadioGroup from "@mui/material/RadioGroup";
import Radio from "@mui/material/Radio";
// import Select from "@mui/material/Select";
// import MenuItem from "@mui/material/MenuItem";
// import Slider from "@mui/material/Slider";
import Button from "@mui/material/Button";
const defaultValues = {
  name: "",
  description: "",
  severity: "",
  imageurl: "",
  videourl: "",
};
const Form = (props) => {
  const [formValues, setFormValues] = useState(defaultValues);
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormValues({
      ...formValues,
      [name]: value,
    });
  };
//   const handleSliderChange = (name) => (e, value) => {
//     setFormValues({
//       ...formValues,
//       [name]: value,
//     });
//   };
  const handleSubmit = (event) => {
    event.preventDefault();
    // console.log(formValues);
		props.onSubmitAddNewMarker(formValues)
  };
  return (
    <div>
			<div style={{display:'flex',justifyContent:'center',alignItems:'center'}}> 
        <h3>Add Marker</h3>
			</div>
      <br />
    <form onSubmit={handleSubmit}>
      <Grid container alignItems="center" justify="center" direction="column">
        <Grid item>
          <TextField
            id="name-input"
            name="name"
            label="Name"
            type="text"
            value={formValues.name}
            onChange={handleInputChange}
          />
        </Grid>
        <br />
        <Grid item>
          <TextField
            id="description-input"
            name="description"
            label="Description"
            type="text"
            multiline
            rows={2}
            value={formValues.description}
            onChange={handleInputChange}
          />
        </Grid>
        <br />
        <Grid item>
          <TextField
            id="imageurl-input"
            name="imageurl"
            label="Image URL"
            type="text"
            multiline
            rows={2}
            value={formValues.imageurl}
            onChange={handleInputChange}
          />
        </Grid>
        <br />
        <Grid item>
          <TextField
            id="videourl-input"
            name="videourl"
            label="Video URL"
            type="text"
            multiline
            rows={2}
            value={formValues.videourl}
            onChange={handleInputChange}
          />
        </Grid>
        <br />
        <Grid item>
          <FormControl>
            <FormLabel>Severity</FormLabel>
            <RadioGroup
              name="severity"
              value={formValues.severity}
              onChange={handleInputChange}
              row
            >
              <FormControlLabel
                key="1"
                value="1"
                control={<Radio size="small" />}
                label="1"
              />
              <FormControlLabel
                key="2"
                value="2"
                control={<Radio size="small" />}
                label="2"
              />
              <FormControlLabel
                key="3"
                value="3"
                control={<Radio size="small" />}
                label="3"
              />
              <FormControlLabel
                key="4"
                value="4"
                control={<Radio size="small" />}
                label="4"
              />
              <FormControlLabel
                key="5"
                value="5"
                control={<Radio size="small" />}
                label="5"
              />
            </RadioGroup>
          </FormControl>
        </Grid>
        
        <Button variant="contained" color="primary" type="submit">
          Submit
        </Button>
      </Grid>
    </form>
    </div>
  );
};
export default Form;