import * as React from 'react';

function MarkerPopup(props) {
  const {info} = props;
  const displayName = `${info.description}`;

  return (
    <div>
      <div>
        <b>Description :</b>{displayName}
      </div>
      <div>
        <b>Severity :</b>{info.severity}
      </div>
      <img alt={"details"} width={240} src={info.imageURL} />
    </div>
  );
}

export default React.memo(MarkerPopup);