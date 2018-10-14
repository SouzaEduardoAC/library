import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import DeleteIcon from '@material-ui/icons/Delete';

const styles = theme => ({
  button: {
    margin: theme.spacing.unit,
  },
  extendedIcon: {
    marginRight: theme.spacing.unit,
  },
});

function RemoveButton(props) {
  const { classes } = props;

  function remove() {
    fetch('http://localhost:8080/api/books/'+ props.id, {
        method: 'delete'
      }).then(res => {
          res.json()
    });
  }

  return (
    <div>
      <Button variant="fab" color="secondary" aria-label="Add" className={classes.button} onClick = { remove() }>
        <DeleteIcon />
      </Button>
    </div>
  );
}

RemoveButton.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(RemoveButton);
