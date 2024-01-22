import React, { useEffect, useState } from 'react';
import CommonInfoService from '../../API/CommonInfoAboutDBs';
import SectionTables from './SectionTables';
import btn from '../../styles/button.module.css'
import cl from './css/main.module.css'
import { Button } from 'react-bootstrap';

const Content = () => {

    const [allDataAboutServer, setAllDataAboutServer] = useState([]);

    useEffect(() => {
        getInfo()
    }, [])

    async function getInfo() {
        const data = await CommonInfoService.getAllMetrics();
        setAllDataAboutServer(data)
    }

    return (
        <div id='content'>
            <div className={cl.actionsBtns}>
                <Button 
                    className={btn.middleBtn}
                    onClick={getInfo}> 
                    Получить данные 
                </Button>
                <Button 
                    className={btn.middleBtn} 
                    disabled> 
                    Создать запрос 
                </Button>
            </div>
            <div>
                <SectionTables data={allDataAboutServer}></SectionTables>
            </div>
        </div>
    );
};

export default Content;
