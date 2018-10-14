import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import DatePicker from './DatePicker';
import AddButton from './PlusButton';

const styles = theme => ({
  container: {
    marginTop: 20,
    marginBotton: 20,
    marginLeft: 100,
    marginRight:100,
    display: 'flex',
    flexWrap: 'wrap',
  },
  textField: {
    marginLeft: theme.spacing.unit,
    marginRight: theme.spacing.unit,
    width: 500,
  },
  dense: {
    marginTop: 19,
  },
  menu: {
    width: 200,
  },
});

class TextFields extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      book: {},
    }
  }


  sendData() {
    if (this.state.book.title == '' 
      | this.state.book.author == '' 
      | this.state.book.releaseDate == '') { return }

    fetch('http://localhost:8080/api/books', {
        method: 'post',
        headers: {
          "Content-Type": "application/json; charset=utf-8",
        },
        body: JSON.stringify(this.state.book), 
      }).then(res => {
          res.json()
    });
  }

  render() {
    const { classes } = this.props;

    return (
      <form className={classes.container} noValidate autoComplete="off" onSubmit={this.sendData()}>
        <TextField
          id="titleInput"
          label="Title"
          ref={this.state.book.title}
          style={{ margin: 8, width: 500 }}
          margin="normal"
          InputLabelProps={{
            shrink: true,
          }}
        />
        <TextField
          id="authorInput"
          label="Author"
          ref={this.state.book.author}
          style={{ margin: 8, width: 500 }}
          margin="normal"
          InputLabelProps={{
            shrink: true,
          }}
        />
        <DatePicker
          id="releaseDateInput"
          label="Release Date"
          ref={this.state.book.releaseDate}
          style={{ margin: 8 }}
          fullWidth
          margin="normal"
          InputLabelProps={{
            shrink: true,
          }}
        />
        <AddButton/>
      </form>
    );
  }
}

TextFields.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(TextFields);
