import React from 'react';
import Connections from './Connections';

const MainSidebarBlock = () => {
    return (
        <div id='menupanel' >
            <div id='menu_panel_header'>
                <h1>DBA SQL Assistant</h1>
            </div>
            <Connections/>
        </div>
    );
};

export default MainSidebarBlock;
