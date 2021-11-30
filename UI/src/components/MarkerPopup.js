import * as React from 'react';

function MarkerPopup(props) {
  const {info} = props;
  const displayName = `${info.description}`;

  return (
    <div>
      <div>
        {displayName} |{' '}
        <a
          target="_new"
          href={`http://en.wikipedia.org/w/index.php?title=Special:Search&search=${displayName}`}
        >
          Wikipedia
        </a>
      </div>
      <img alt={"details"} width={240} src={info.image} />
    </div>
  );
}

export default React.memo(MarkerPopup);